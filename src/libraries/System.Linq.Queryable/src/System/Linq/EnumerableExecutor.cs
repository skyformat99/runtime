// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq
{
    public abstract class EnumerableExecutor
    {
        internal abstract object? ExecuteBoxed();

        internal EnumerableExecutor() { }

        internal static EnumerableExecutor Create(Expression expression)
        {
            Type execType = typeof(EnumerableExecutor<>).MakeGenericType(expression.Type);
            return (EnumerableExecutor)Activator.CreateInstance(execType, expression)!;
        }
    }

    public class EnumerableExecutor<T> : EnumerableExecutor
    {
        private readonly Expression _expression;

        public EnumerableExecutor(Expression expression)
        {
            _expression = expression;
        }

        internal override object? ExecuteBoxed() => Execute();

        internal T Execute()
        {
            EnumerableRewriter rewriter = new EnumerableRewriter();
            Expression body = rewriter.Visit(_expression);
            Expression<Func<T>> f = Expression.Lambda<Func<T>>(body, (IEnumerable<ParameterExpression>?)null);
            Func<T> func = f.Compile();
            return func();
        }
    }
}

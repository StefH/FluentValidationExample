using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentValidationExample.Web.Validation
{
    public interface IFluentValidationPropertyNameResolver
    {
        /// <summary>
        /// Resolves the property name for the specified type, memberInfo and lambdaExpression.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="memberInfo">The member information.</param>
        /// <param name="lambdaExpression">The lambda expression.</param>
        /// <returns>Property Name</returns>
        string Resolve(Type type, MemberInfo memberInfo, LambdaExpression lambdaExpression);
    }
}

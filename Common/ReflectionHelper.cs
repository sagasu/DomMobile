// -----------------------------------------------------------------------
// <copyright file="ReflectionHelper.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// The holder of static methods for operating on the expressions.
    /// </summary>
    public class ReflectionHelper
    {
        private const string _NotPropertyExceptionMessage = "The passed expression does not describe a property";

        private const string _DefaultSeparator = "."; //Separator between objects, for web u may want to change it to _

        /// <summary>
        /// Create a path of an expression. For an id in a web use _ as a separator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string GetExpressionAsString<T>(Expression<Func<T, object>> expression, string separator = _DefaultSeparator)
        {
            if(expression.Parameters.Count != 1)
            {
                throw new ArgumentException("Sorry this method currently supports just one parameter");
            }

            var parameter = expression.Parameters.First();

            if (expression.Body is UnaryExpression)
            {
                var unex = (UnaryExpression)expression.Body;
                if (unex.NodeType == ExpressionType.Convert)
                {
                    Expression ex = unex.Operand;
                    //var mex = (MemberExpression)ex;
                    return unex.Operand.ToString().Replace(parameter.Name + ".", string.Empty).Replace(_DefaultSeparator, separator);
                }
            }
            
            //var methodCall = (MethodCallExpression)expression.Body;

            return expression.Body.ToString().Replace(_DefaultSeparator, separator);
        }

        /// <summary>
        /// Gets the <see cref="MethodInfo"/> from the passed expression.
        /// </summary>
        /// <typeparam name="T">The type of the interface/class, which method is passed as the expression.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The method info.</returns>
        public static MethodInfo GetMethod<T>(Expression<Func<T, object>> expression)
        {
            var methodCall = (MethodCallExpression)expression.Body;
            return methodCall.Method;
        }

        /// <summary>
        /// Gets the <see cref="MethodInfo"/> from the passed expression.
        /// </summary>
        /// <typeparam name="T">The type of the interface/class, which method is passed as the expression.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The method info.</returns>
        public static MethodInfo GetMethod<T>(Expression<Action<T>> expression)
        {
            var methodCall = (MethodCallExpression)expression.Body;
            return methodCall.Method;
        }

        /// <summary>
        /// Gets the property  from the passed expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The property info.</returns>
        public static PropertyInfo GetProperty<TModel>(Expression<Func<TModel, object>> expression)
        {
            var result = GetMember(expression) as PropertyInfo;
            if (result != null)
            {
                return result;
            }

            throw new ArgumentException(_NotPropertyExceptionMessage);
        }

        /// <summary>
        /// Gets the property  from the passed expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The property info.</returns>
        public static PropertyInfo GetProperty<TModel, TReturn>(Expression<Func<TModel, TReturn>> expression)
        {
            var result = GetMember(expression) as PropertyInfo;
            if (result != null)
            {
                return result;
            }

            throw new ArgumentException(_NotPropertyExceptionMessage);
        }

        /// <summary>
        /// Gets the member from the passed expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The property info.</returns>
        public static MemberInfo GetMember<TModel>(Expression<Func<TModel, object>> expression)
        {
            return GetMember(expression.Body);
        }

        /// <summary>
        /// Gets the member from the passed expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The property info.</returns>
        public static MemberInfo GetMember<TModel, TReturn>(Expression<Func<TModel, TReturn>> expression)
        {
            return GetMember(expression.Body);
        }

        private static MemberExpression GetMemberExpression(Expression expression)
        {
            return GetMemberExpression(expression, true);
        }

        private static MemberInfo GetMember(Expression expression)
        {
            if (IsMethodExpression(expression))
            {
                return ((MethodCallExpression)expression).Method;
            }

            return GetMemberExpression(expression).Member;
        }

        private static MemberExpression GetMemberExpression(Expression expression, bool enforceCheck)
        {
            MemberExpression operand = null;
            if (expression.NodeType == ExpressionType.Convert)
            {
                var expression3 = (UnaryExpression)expression;
                operand = expression3.Operand as MemberExpression;
            }
            else if (expression.NodeType == ExpressionType.MemberAccess)
            {
                operand = expression as MemberExpression;
            }

            if (enforceCheck && (operand == null))
            {
                throw new ArgumentException("Not a member access", "expression");
            }

            return operand;
        }

        private static bool IsMethodExpression(Expression expression)
        {
            return
                (expression is MethodCallExpression) ||
                ((expression is UnaryExpression) && IsMethodExpression((expression as UnaryExpression).Operand));
        }
    }

}

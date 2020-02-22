using System;
using System.Linq.Expressions;

namespace Learning.CodeDOM
{
    public class CompileLambda
    {
        public void Process()
        {
            ParameterExpression quotient = Expression.Parameter(typeof(float), "x");

            ConstantExpression divider = Expression.Constant(2f, typeof(float));

            BinaryExpression @operator = Expression.Divide(quotient, divider);

            Expression<Func<float, float>> expression = Expression.Lambda<Func<float, float>>(
                    @operator,
                    new ParameterExpression[] { quotient }
                    );

            Func<float,float> theHalf = quot => quot / 2;

            var myHalf = expression.Compile();

            Console.WriteLine(theHalf(9));
            Console.WriteLine(myHalf(9));

            ChangeDivideByDouble change = new ChangeDivideByDouble();

            Expression<Func<float, float>> @double = (Expression<Func<float, float>>)change.Modify(expression);

            Console.WriteLine();
            var myDouble = @double.Compile();
            Console.WriteLine(myDouble(10));
        }

    }

    class ChangeDivideByDouble : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if(node.NodeType == ExpressionType.Divide)
            {
                return Expression.Multiply(node.Left, node.Right);
            }

            return node;
        }
    }
}

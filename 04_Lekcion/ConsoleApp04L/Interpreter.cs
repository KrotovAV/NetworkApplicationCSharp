using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Interpreter
    abstract class Expression
    {
        public abstract bool Interpret(string context);
    }

    class TerminalExpression : Expression
    {
        private string data;

        public TerminalExpression(string data)
        {
            this.data = data;
        }

        public override bool Interpret(string context)
        {
            return context.Contains(data);
        }
    }

    class AndExpression : Expression
    {
        private Expression expr1;
        private Expression expr2;

        public AndExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public override bool Interpret(string context)
        {
            return expr1.Interpret(context) && expr2.Interpret(context);
        }
    }
}

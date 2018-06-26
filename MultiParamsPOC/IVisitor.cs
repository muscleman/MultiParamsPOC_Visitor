using MultiParamsPOC.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MultiParamsPOC
{
    public interface IVisitor<T>
    {
        void visit(string type, string node);
        void visit(string type, int node);
    }

    public class EvalVisitor<T> : IVisitor<T> where T : User
    {
        public void visit(string type, string node)
        {
            //throw new NotImplementedException();
            Debug.Print("string evaluator");
        }

        public void visit(string type, int node)
        {
            Debug.Print("integer evaluator");
            //throw new NotImplementedException();
        }
    }
}

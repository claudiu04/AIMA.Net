namespace AIMA.Core.Logic.FOL.Parsing.AST
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using AIMA.Core.Logic.FOL.Parsing;
    using System.Collections.ObjectModel;

    /**
     * @author Ravi Mohan
     * @author Ciaran O'Reilly
     */
    public class Predicate : AtomicSentence
    {
        private String predicateName;
        private List<Term> terms = new List<Term>();
        private String stringRep = null;
        private int hashCode = 0;

        public Predicate(String predicateName, List<Term> terms)
        {
            this.predicateName = predicateName;
            this.terms.AddRange(terms);
        }

        public String getPredicateName()
        {
            return predicateName;
        }

        public List<Term> getTerms()
        {
            return terms.AsReadOnly().ToList<Term>();
        }

        //
        // START-AtomicSentence
        public String getSymbolicName()
        {
            return getPredicateName();
        }

        public bool isCompound()
        {
            return true;
        }

        public List<FOLNode> getArgs()
        {
            return getTerms().ToList<FOLNode>();
        }

        public Object accept(FOLVisitor v, Object arg)
        {
            return v.visitPredicate(this, arg);
        }

        public FOLNode copy()
        {
            List<Term> copyTerms = new List<Term>();
            foreach (Term t in terms)
            {
                copyTerms.Add((Term)t.copy());
            }
            return new Predicate(predicateName, copyTerms);
        }

        // END-AtomicSentence
        //

        public override bool Equals(Object o)
        {

            if (this == o)
            {
                return true;
            }
            if (!(o is Predicate))
            {
                return false;
            }
            Predicate p = (Predicate)o;
            return p.getPredicateName().Equals(getPredicateName())
                    && p.getTerms().Equals(getTerms());
        }

        public override int GetHashCode()
        {
            if (0 == hashCode)
            {
                hashCode = 17;
                hashCode = 37 * hashCode + predicateName.GetHashCode();
                foreach (Term t in terms)
                {
                    hashCode = 37 * hashCode + t.GetHashCode();
                }
            }
            return hashCode;
        }

        public override String ToString()
        {
            if (null == stringRep)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(predicateName);
                sb.Append("(");

                bool first = true;
                foreach (Term t in terms)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.Append(",");
                    }
                    sb.Append(t.ToString());
                }

                sb.Append(")");
                stringRep = sb.ToString();
            }

            return stringRep;
        }
    }
}
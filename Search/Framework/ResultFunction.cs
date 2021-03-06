namespace AIMA.Core.Search.Framework
{
    using System.Collections.Generic;
    using AIMA.Core.Agent;

    /**
     * Artificial Intelligence A Modern Approach (3rd Edition): page 67.
     * 
     * A description of what each action does; the formal name for this is the
     * transition model, specified by a function RESULT(s, a) that returns the state
     * that results from doing action a in state s. We also use the term successor
     * to refer to any state reachable from a given state by a single action.
     */
    public interface ResultFunction
    {
        /**
         * Returns the state that results from doing action a in state s
         * 
         * @param s
         *            a particular state.
         * @param a
         *            an action to be performed in state s.
         * @return the state that results from doing action a in state s.
         */
        System.Object result(System.Object s, Action a);
    }
}
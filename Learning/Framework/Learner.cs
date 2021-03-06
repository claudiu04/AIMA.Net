namespace AIMA.Core.Learning.Framework
{
    using System;
    using System.Collections.Generic;
    /**
     * @author Ravi Mohan
     * 
     */
    public interface Learner
    {
        void train(DataSet ds);

        String predict(Example e);

        int[] test(DataSet ds);
    }
}
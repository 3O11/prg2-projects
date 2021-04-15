namespace Calculator {
    class Calc {
        /// <summary>
        /// Initialize Calculator with operators, source and output.
        /// </summary>
        /// <param name="operators"></param>
        /// <param name="source"></param>
        /// <param name="output"></param>
        public Calc(IOperator[] operators, ISource source, IOutput output) {
            this.operators = operators;
            this.source = source;
            this.output = output;
        }
        /// <summary>
        /// This method can be called only when the Calculator is completely set up.
        /// The operators, source and output have to be set.
        /// </summary>
        public void Process() {
            output.Output(ans.ToString());
            while (source.HasNext()) {
                bool processed = false;
                string nextOp = source.GetLine();

                foreach(var op in operators){
                    if(op.CanProcess(nextOp)) {
                        ans = op.Process(ans, nextOp);
                        output.Output(ans.ToString());
                        processed = true;
                    }
                }
                if (!processed) output.Output("Invalid input");
            }

        }

        double ans = 0;
        IOperator[] operators;
        ISource source;
        IOutput output;
    }
}

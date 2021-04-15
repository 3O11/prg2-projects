namespace Calculator {
    interface IOperator {
        public bool CanProcess(string line);
        public  double Process(double left, string right);
    }
}

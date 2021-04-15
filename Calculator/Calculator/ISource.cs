namespace Calculator {
    interface ISource {
        public bool HasNext();
        public string GetLine();
    }
}

namespace AxinLib.IO.CSV.States
{
    public static class StateHolder
    {
        public static IState NewFieldState { get; } = new NewFieldState();

        public static IState NonEscapeState { get; } = new NonEscapeState();

        public static IState EscapeState { get; } = new EscapeState();

        public static IState LiteralInferState { get; } = new LiteralInferState();

        public static IState FieldEndState { get; } = new FieldEndState();

        public static IState RowEndState { get; } = new RowEndState();

        public static IState FileEndState { get; } = new FileEndState();
    }
}
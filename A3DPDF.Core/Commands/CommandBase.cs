
namespace A3DPDF.Core.Commands
{
    public abstract class CommandBase :ICommand
    {
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChagned()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler? CanExecuteChanged;
        

    }
}

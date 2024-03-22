namespace DemoBlazor.Models;

public class AppState
{
    public int SelectedNumber { get; set; }
    public event Action? OnChange;

    public void SetSelectedNumber(int number)
    {
        SelectedNumber = number;
        NotifyStateChanged();
    }
    private void NotifyStateChanged() => OnChange?.Invoke();
}

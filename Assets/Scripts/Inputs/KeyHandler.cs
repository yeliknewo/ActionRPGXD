namespace Inputs
{
	public abstract class KeyHandler
	{
		internal abstract bool IsButton();
		internal abstract bool IsInvertAxis();
		internal abstract string GetInputName();
		internal abstract bool IsX();
		internal abstract bool IsY();
	}
}


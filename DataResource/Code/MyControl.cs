private int borderSize = 2;
private Color borderColor = Color.Black;

public int BorderSize
{
	get => borderSize;
	set
	{
		borderSize = value;
		this.Invalidate();
	}
}

public Color BorderColor
{
	get => borderColor; set
	{
		borderColor = value;
		this.Invalidate();
	}
}

//Override method
protected override void OnPaint(PaintEventArgs e)
{
	base.OnPaint(e);
	Graphics graph = e.Graphics;
	using (Pen penBorder = new Pen(BorderColor, borderSize))
	{
		penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
		graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);

	}
}

protected override void OnResize(EventArgs e)
{
	base.OnResize(e);
	if (this.DesignMode)
		UpdateControlHeight();
}

protected override void OnLoad(EventArgs e)
{
	base.OnLoad(e);
	UpdateControlHeight();
}

private void UpdateControlHeight()
{
	if (textBox1.Multiline == false)
	{
		int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
		textBox1.Multiline = true;
		textBox1.MinimumSize = new Size(0, txtHeight);
		textBox1.Multiline = false;
	}
	this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;


}
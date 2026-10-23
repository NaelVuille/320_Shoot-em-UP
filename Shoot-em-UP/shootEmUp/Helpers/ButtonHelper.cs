using shootEmUp.Properties;
namespace shootEmUp.Helpers
{
    public static class ButtonHelper
    {
        public static void Configure(Button butt)
        {
            butt.FlatStyle = FlatStyle.Flat;
            butt.FlatAppearance.BorderSize = 0;

            butt.Font = TextHelpers.MediumFont;

            Image normalImage = Resources.buttonFrame;
            Image hoverImage = Resources.selectButtonFrame;

            butt.MouseEnter += (sender, e) => { butt.BackgroundImage = hoverImage; };
            butt.MouseLeave += (sender, e) => { butt.BackgroundImage = normalImage; };

            butt.GotFocus += (sender, e) => { butt.BackgroundImage = hoverImage; };
            butt.LostFocus += (sender, e) => { butt.BackgroundImage = normalImage; };
        }
    }
}

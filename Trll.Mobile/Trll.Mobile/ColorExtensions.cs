using Xamarin.Forms;

namespace Trll.Mobile
{
    public static class ColorExtensions
    {
        public static string ToColorCode(this string colorName)
        {
            switch (colorName)
            {
                case "green":
                    return "#61BD4F";
                case "yellow":
                    return "#F2D600";
                case "orange":
                    return "#FFAB4A";
                case "red":
                    return "#EB5A46";
                case "purple":
                    return "#C377E0";
                case "blue":
                    return "#0079BF";
                case "sky":
                    return "#00C2E0";
                case "lime":
                    return "#51E898";
                case "pink":
                    return "#FF80CE";
                case "black":
                default:
                    return "#4d4d4d";


            }
        }
    }
}
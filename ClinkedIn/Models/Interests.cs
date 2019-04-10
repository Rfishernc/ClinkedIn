using System.ComponentModel;

namespace ClinkedIn.Models
{
    // shape of json get request for FindMembersController
    public class InterstFilter
    {
        public int[] InterestIds { get; set; }
    }

    // interests for inmates
    enum Interests
    {
        [Description("Toilet wine crafting and drinking")]
        Wine,
        [Description("Liftin' weights to get strong")]
        Weights,
        [Description("Food fills my soul with joy")]
        Food,
        [Description("Reading the time away")]
        Reading,
        [Description("I do religion sometimes")]
        Religion,
        [Description("We all daydream, I just do it more than most")]
        Daydream
    }
}

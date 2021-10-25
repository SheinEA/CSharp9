
const string text = "Hello {0}!";

static void PromoteCountry(Func<string, string> func){
    WriteLine(nameof(PromoteCountry));
}

PromoteCountry(static t => string.Format(text, t));
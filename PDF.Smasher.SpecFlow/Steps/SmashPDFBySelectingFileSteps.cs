using System;
using TechTalk.SpecFlow;

namespace PDF.Smasher.SpecFlow.Steps
{
    [Binding]
    public class SmashPDFBySelectingFileSteps
    {
        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I click on the Upload PDF box")]
        public void GivenIClickOnTheUploadPDFBox()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I select a PDF that is certified")]
        public void GivenISelectAPDFThatIsCertified()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I click on the smash button")]
        public void GivenIClickOnTheSmashButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I confirm the smash")]
        public void GivenIConfirmTheSmash()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the application will download the same PDF but without the certification")]
        public void ThenTheApplicationWillDownloadTheSamePDFButWithoutTheCertification()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

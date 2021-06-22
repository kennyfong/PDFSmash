Feature: SmashPDFBySelectingFile
	Flatten a PDF document so that users can digitally sign it

@mytag
Scenario: Flatten a PDF document
	Given I launch the application
	And I click on the Upload PDF box
	And I select a PDF that is certified
	And I click on the smash button
	And I confirm the smash
	Then the application will download the same PDF but without the certification
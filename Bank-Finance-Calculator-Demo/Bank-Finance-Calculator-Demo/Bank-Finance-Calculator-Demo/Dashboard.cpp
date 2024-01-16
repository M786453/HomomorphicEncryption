#include "Dashboard.h"

using namespace System;
using namespace System::Windows::Forms;

void main(array<String^>^ args)
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	BankFinanceCalculatorDemo::Dashboard dashboard;
	Application::Run(% dashboard);

}
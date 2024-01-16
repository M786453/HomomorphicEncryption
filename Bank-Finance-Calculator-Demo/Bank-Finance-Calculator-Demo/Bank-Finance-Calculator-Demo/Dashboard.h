#pragma once
#include "Calculator.h"
#include "Performance.h"

namespace BankFinanceCalculatorDemo {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Dashboard
	/// </summary>
	public ref class Dashboard : public System::Windows::Forms::Form
	{
	public:
		Dashboard(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Dashboard()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Button^ btnCalculator;
	private: System::Windows::Forms::Button^ btnPerformance;



	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(Dashboard::typeid));
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->btnCalculator = (gcnew System::Windows::Forms::Button());
			this->btnPerformance = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->ForeColor = System::Drawing::Color::Black;
			this->label1->Location = System::Drawing::Point(229, 151);
			this->label1->Margin = System::Windows::Forms::Padding(0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(490, 89);
			this->label1->TabIndex = 0;
			this->label1->Text = resources->GetString(L"label1.Text");
			this->label1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			this->label1->Click += gcnew System::EventHandler(this, &Dashboard::label1_Click);
			// 
			// label2
			// 
			this->label2->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->label2->Font = (gcnew System::Drawing::Font(L"Impact", 20, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label2->Location = System::Drawing::Point(183, 92);
			this->label2->Margin = System::Windows::Forms::Padding(0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(590, 45);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Bank Finance Calculator";
			this->label2->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			this->label2->Click += gcnew System::EventHandler(this, &Dashboard::label2_Click);
			// 
			// btnCalculator
			// 
			this->btnCalculator->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->btnCalculator->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->btnCalculator->Location = System::Drawing::Point(378, 276);
			this->btnCalculator->Margin = System::Windows::Forms::Padding(2);
			this->btnCalculator->Name = L"btnCalculator";
			this->btnCalculator->Size = System::Drawing::Size(210, 36);
			this->btnCalculator->TabIndex = 2;
			this->btnCalculator->Text = L"Calculator";
			this->btnCalculator->UseVisualStyleBackColor = true;
			this->btnCalculator->Click += gcnew System::EventHandler(this, &Dashboard::btnCalculator_Click);
			// 
			// btnPerformance
			// 
			this->btnPerformance->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->btnPerformance->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->btnPerformance->Location = System::Drawing::Point(378, 325);
			this->btnPerformance->Margin = System::Windows::Forms::Padding(2);
			this->btnPerformance->Name = L"btnPerformance";
			this->btnPerformance->Size = System::Drawing::Size(210, 39);
			this->btnPerformance->TabIndex = 3;
			this->btnPerformance->Text = L"Performance";
			this->btnPerformance->UseVisualStyleBackColor = true;
			this->btnPerformance->Click += gcnew System::EventHandler(this, &Dashboard::btnPerformance_Click);
			// 
			// Dashboard
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::Control;
			this->ClientSize = System::Drawing::Size(925, 451);
			this->Controls->Add(this->btnPerformance);
			this->Controls->Add(this->btnCalculator);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Dashboard";
			this->StartPosition = System::Windows::Forms::FormStartPosition::Manual;
			this->Text = L"Bank Finance Calculator";
			this->Load += gcnew System::EventHandler(this, &Dashboard::Dashboard_Load);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void label1_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void label2_Click(System::Object^ sender, System::EventArgs^ e) {
	}
private: System::Void btnCalculator_Click(System::Object^ sender, System::EventArgs^ e) {

	Calculator^ calculator = gcnew Calculator();

	// Show calculator
	calculator->Show();

}
private: System::Void Dashboard_Load(System::Object^ sender, System::EventArgs^ e) {

	this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;

	this->StartPosition = FormStartPosition::Manual;

	Screen^ primaryScreen = Screen::PrimaryScreen;

	this->Size = primaryScreen->WorkingArea.Size;

	this->Location = primaryScreen->WorkingArea.Location;

}
private: System::Void btnPerformance_Click(System::Object^ sender, System::EventArgs^ e) {

	Performance^ performance = gcnew Performance();

	//Show performance
	performance->Show();
}
};
}

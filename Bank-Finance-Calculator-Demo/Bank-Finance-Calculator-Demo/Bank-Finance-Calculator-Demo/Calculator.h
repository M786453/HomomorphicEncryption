#pragma once

namespace BankFinanceCalculatorDemo {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Calculator
	/// </summary>
	public ref class Calculator : public System::Windows::Forms::Form
	{
	public:
		Calculator(void)
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
		~Calculator()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ activity_logs;
	private: System::Windows::Forms::Label^ output;
	private: System::Windows::Forms::Button^ avg_transaction;
	private: System::Windows::Forms::Button^ balance;
	private: System::Windows::Forms::Button^ charges;



	private: System::Windows::Forms::Label^ label1;



	protected:

	protected:


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
			this->activity_logs = (gcnew System::Windows::Forms::Label());
			this->output = (gcnew System::Windows::Forms::Label());
			this->avg_transaction = (gcnew System::Windows::Forms::Button());
			this->balance = (gcnew System::Windows::Forms::Button());
			this->charges = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// activity_logs
			// 
			this->activity_logs->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->activity_logs->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->activity_logs->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->activity_logs->ForeColor = System::Drawing::SystemColors::Control;
			this->activity_logs->Location = System::Drawing::Point(-2, 330);
			this->activity_logs->Name = L"activity_logs";
			this->activity_logs->Padding = System::Windows::Forms::Padding(10);
			this->activity_logs->Size = System::Drawing::Size(768, 229);
			this->activity_logs->TabIndex = 0;
			this->activity_logs->Text = L"Activity Logs";
			// 
			// output
			// 
			this->output->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->output->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->output->Location = System::Drawing::Point(1, 279);
			this->output->Name = L"output";
			this->output->Size = System::Drawing::Size(765, 51);
			this->output->TabIndex = 1;
			this->output->Text = L"Calculation Output:";
			this->output->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// avg_transaction
			// 
			this->avg_transaction->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->avg_transaction->Location = System::Drawing::Point(202, 58);
			this->avg_transaction->Name = L"avg_transaction";
			this->avg_transaction->Size = System::Drawing::Size(354, 51);
			this->avg_transaction->TabIndex = 2;
			this->avg_transaction->Text = L"Average Transaction";
			this->avg_transaction->UseVisualStyleBackColor = true;
			// 
			// balance
			// 
			this->balance->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->balance->Location = System::Drawing::Point(202, 127);
			this->balance->Name = L"balance";
			this->balance->Size = System::Drawing::Size(354, 51);
			this->balance->TabIndex = 3;
			this->balance->Text = L"Balance Amount";
			this->balance->UseVisualStyleBackColor = true;
			// 
			// charges
			// 
			this->charges->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->charges->Location = System::Drawing::Point(202, 197);
			this->charges->Name = L"charges";
			this->charges->Size = System::Drawing::Size(354, 51);
			this->charges->TabIndex = 4;
			this->charges->Text = L"Bank Charges";
			this->charges->UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this->label1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->label1->Location = System::Drawing::Point(2, 19);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(764, 20);
			this->label1->TabIndex = 5;
			this->label1->Text = L"Note: Input filename should be \'Data.csv\'";
			this->label1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// Calculator
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(9, 20);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(767, 558);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->charges);
			this->Controls->Add(this->balance);
			this->Controls->Add(this->avg_transaction);
			this->Controls->Add(this->output);
			this->Controls->Add(this->activity_logs);
			this->Name = L"Calculator";
			this->Text = L"Bank Finance Calculator";
			this->ResumeLayout(false);

		}
#pragma endregion
	};
}

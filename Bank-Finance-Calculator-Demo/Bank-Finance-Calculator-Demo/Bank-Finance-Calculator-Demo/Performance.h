#pragma once

namespace BankFinanceCalculatorDemo {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Performance
	/// </summary>
	public ref class Performance : public System::Windows::Forms::Form
	{
	public:
		Performance(void)
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
		~Performance()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ perf_lablel;
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
			this->perf_lablel = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// perf_lablel
			// 
			this->perf_lablel->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->perf_lablel->Location = System::Drawing::Point(2, 128);
			this->perf_lablel->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->perf_lablel->Name = L"perf_lablel";
			this->perf_lablel->Size = System::Drawing::Size(513, 40);
			this->perf_lablel->TabIndex = 0;
			this->perf_lablel->Text = L"No data to show!";
			this->perf_lablel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			this->perf_lablel->Click += gcnew System::EventHandler(this, &Performance::label1_Click);
			// 
			// Performance
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(515, 325);
			this->Controls->Add(this->perf_lablel);
			this->Margin = System::Windows::Forms::Padding(2, 2, 2, 2);
			this->Name = L"Performance";
			this->Text = L"Bank Finance Calculator";
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void label1_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	};
}

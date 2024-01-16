#include "cal.h"
#include <vector>
#include <string>
#include "csvreader.h"

std::string avg_trans() {

	std::vector<std::vector<std::string>> rows = readCsv();

	// Show Plaintext Data to Users

	std::string rowText;

	rowText += "> Reading Data.csv File...\n";

	for (const auto& row : rows) {

		for (const auto& value : row) {
	
			rowText += value + ", ";
		}

		rowText += "\n";
	}


	return rowText;
}
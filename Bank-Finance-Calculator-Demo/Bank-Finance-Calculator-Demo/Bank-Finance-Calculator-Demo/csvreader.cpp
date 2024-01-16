#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <string>
#include "csvreader.h"

std::vector<std::vector<std::string>> readCsv() {
    // Open the CSV file
    std::ifstream file("F:/Workspace/C-plus-plus/Homomorphic-Encryption/Data.csv");

    // Vector to store rows
    std::vector<std::vector<std::string>> rows;

    // Check if the file is open
    if (!file.is_open()) {
        std::cerr << "Error opening the file." << std::endl;
        return rows;
    }

    // Read the file line by line
    std::string line;
    while (std::getline(file, line)) {
        std::vector<std::string> row;
        std::istringstream iss(line);
        std::string value;

        // Read each value separated by commas
        while (std::getline(iss, value, ',')) {
            row.push_back(value);
        }

        rows.push_back(row);
    }

    // Close the file
    file.close();

    return rows;
}

/*
* Character Counter - Made by ZiYueCommentary
* Counting characters that existing in the file.
* 
* v1.1 2022/12/16
* 
* Download Executable: https://files.ziyuesinicization.site/cc.exe
*/

#include <fstream>
#include <iostream>
#include <map>

typedef unsigned char byte;

struct utf8 {
	byte size;
	byte bytes[6];

	std::strong_ordering operator<=>(const utf8& u8) const = default; // i must to do this or i can't to compile
};

int main(int argc, char* argv[]) {
	if (argc == 3) {
		byte c;
		unsigned int offset = 0;
		std::ifstream is(argv[1]);
		std::ofstream os(argv[2], std::ios::binary);
		if (!is.good()) {
			std::cerr << "Reading input file failed: " << argv[1];
			return EXIT_FAILURE;
		}
		if (!os.good()) {
			std::cerr << "Unable to write the output file: " << argv[2];
			return EXIT_FAILURE;
		}
		std::map<utf8, bool> chars;
		while (!is.eof()) {
			is.seekg(offset);
			is.read((char*)&c, 1);
			if ((c >> 7) == 0x0) { // 0xxxxxxx -> ASCII
				// For some reason, changing "offset" will trap in the death loop
				utf8 u8;
				u8.size = 1;
				u8.bytes[0] = c;
				if (!chars.contains(u8)) chars[u8] = true;
			}
			else {
				byte size = 0;
				if ((c >> 5) == 0x6) { // 110xxxxx
					size = 2;
				}
				else if ((c >> 4) == 0xE) { // 1110xxxx
					size = 3;
				}
				else if ((c >> 3) == 0x1E) { // 11110xxx -> Emoji!
					size = 4;
				}
				else if ((c >> 2) == 0x3E) { // 111110xx
					size = 5;
				}
				if ((c >> 1) == 0x7E) { // 1111110x
					size = 6;
				}

				offset--;
				utf8 u8;
				u8.size = size;
				for (int i = 0; i < size; i++) {
					offset++;
					is.seekg(offset);
					is.read((char*)&c, 1);
					u8.bytes[i] = c;
				}
				if (!chars.contains(u8)) chars[u8] = true;
			}
			offset++;
		}
		for (auto u8 = chars.begin(); u8 != chars.end(); u8++) {
			for (int i = 0; i < u8->first.size; i++) {
				byte b = u8->first.bytes[i];
				if ((b != '\r') && (b != '\n')) os << b; // skip line feed
			}
		}
	}
	else {
		std::cout << "Counting characters that existing in the file.\n"
			"\n"
			"cc -i -o\n"
			"\n"
			"-i\tAppoint the file that needs to count.\n"
			"-o\tThe output file that saves characters that were counted.\n"
			"NOTE: This tool is for UTF-8 only.\n"
			"\n"
			"For example: cc foo.txt bar.txt\n";
	}
	return EXIT_SUCCESS;
}
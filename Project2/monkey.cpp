#include <iostream>

extern void __cdecl render();

int __cdecl main(int argc, char* argv[]) {
	for (;;) {
		clock_t begin = clock();
		render();
		clock_t end = clock();
		std::cout << double(end - begin) / CLOCKS_PER_SEC << "\n";
	}
	return 0;

	std::ios::sync_with_stdio(false);
	std::cin.tie(0);
	unsigned pos = 0;
	unsigned times = 0;
	std::string content = argc >= 2 ? argv[1] : "";
	if (content == "") {
		std::cout << "Content: ";
		std::cin >> content;
	}

	clock_t begin, end;
	begin = clock();
	for (;;) {
		char chara = rand() % (126 - 33 + 1) + 33;
		//std::cout << chara;
		if (chara == content[pos]) {
			if (pos == content.length() - 1) { times++; break; }
			pos++;
			times++;
			continue;
		}
		pos = 0;
		times++;
	}
	end = clock();
	std::cout << std::endl << "完毕，共" << times << "次，时长" << double(end - begin) / CLOCKS_PER_SEC * 1000 / 1000 << "秒。" << std::endl;
}
#include <iostream>

int main(int argc, char* argv[]) {
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
	std::cout << std::endl << "��ϣ���" << times << "�Σ�ʱ��" << double(end - begin) / CLOCKS_PER_SEC * 1000 / 1000 << "�롣" << std::endl;
}
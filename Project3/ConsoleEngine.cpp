#include <iostream>
#include <conio.h>
#include <thread>
#include <windows.h>
using namespace std;

namespace ConsoleEngine {
	typedef unsigned int uint;
	constexpr uint SIZE = 50; // ͼ���С

	__interface IRenderable;
	class Layer;
	class RenderSystem;

	/*
	* һ���ӿڣ�����Ⱦ�����ݱ���̳д˽ӿ�
	* �Ҳ���__interface�ؼ���ֱ���滻��class����
	*/
	__interface IRenderable
	{
	public:
		Layer* join(Layer* layer); // ���Լ���ӵ�һ��ͼ��
	};

	/*
	* ͼ���࣬����������Ⱦ�������
	*/
	class Layer : public IRenderable {
	public:
		std::string name;
		char layer[SIZE][SIZE]{ ' ' };

		Layer(std::string name = "Unnamed") {
			this->name = name;
		}

		~Layer() { // ����ͼ������
			for (uint i = 0; i < SIZE; i++)
			{
				delete[] layer[i];
			}
			delete[] layer;
		}

		Layer* join(Layer* layer) { // �ϲ�����ͼ��
			for (uint i = 0; i < SIZE; i++) {
				for (uint j = 0; j < SIZE; j++) {
					if (this->layer[i][j] == ' ') continue;
					layer->layer[i][j] = this->layer[i][j];
				}
			}
			return layer;
		}
	};

	/*
	* ��Ⱦϵͳ��������Ⱦͼ��
	*/
	class RenderSystem {
	private:
		bool debug;
		Layer* current = nullptr;
	public:
		RenderSystem(bool debug = false) {
			this->debug = debug;
		}

		bool isDebug() {
			return debug;
		}

		void render(Layer* layer) { // ��Ⱦͼ�㣬ͬһʱ��ֻ����Ⱦһ��
			current = layer;
			clock_t begin, end;
			begin = clock();
			system("cls");
			for (uint i = 0; i < SIZE; i++) {
				for (uint j = 0; j < SIZE; j++) {
					printf("%c", layer->layer[i][j]);
				}
				printf("\n");
			}
			end = clock();
			if (debug) std::cout << layer->name << "ͼ����Ⱦ��ϣ���ʱ" << double(end - begin) / CLOCKS_PER_SEC * 1000 << "���롣";
		}

		void flush() {
			if (current == nullptr) return;
			render(current);
		}

		void filter(const char* color) { // �˾�
			system(("color "s + color).c_str());
		}
	};

	class Rect : public IRenderable {
	public:
		uint x, y, width, height;
		bool fill;

		Rect(uint x, uint y, uint width, uint height, bool fill = true) {
			this->x = x;
			this->y = y;
			this->width = width;
			this->height = height;
			this->fill = fill;
		}

		Layer* join(Layer* layer) {
			for (uint i = 0; i < height; i++) {
				for (uint j = 0; j < width; j++) {
					if (i > 0 && i < height - 1 && j > 0 && j < width - 1) {
						if (!fill) continue;
					}
					layer->layer[i + y][j + x] = '*';
				}
			}
			return layer;
		}
	};

	class Text : public IRenderable {
	public:
		uint x, y, length;
		std::string string;

		Text(uint x, uint y, const char* string) {
			length = (std::string(string)).length();
			this->string = string;
			this->x = x;
			this->y = y;
		}

		Text(uint x, uint y, std::string string) {
			length = string.length();
			this->string = string;
			this->x = x;
			this->y = y;
		}

		Layer* join(Layer* layer) {
			for (uint i = 0; i < length; i++) {
				layer->layer[y][x + i] = string[i];
			}
			return layer;
		}
	};
}
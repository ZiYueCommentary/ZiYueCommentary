#include <iostream>
#include <conio.h>
#include <thread>
#include <windows.h>
using namespace std;

namespace ConsoleEngine {
	typedef unsigned int uint;
	constexpr uint SIZE = 50; // 图层大小

	__interface IRenderable;
	class Layer;
	class RenderSystem;

	/*
	* 一个接口，可渲染的内容必须继承此接口
	* 找不到__interface关键字直接替换成class就行
	*/
	__interface IRenderable
	{
	public:
		Layer* join(Layer* layer); // 将自己添加到一个图层
	};

	/*
	* 图层类，允许多个可渲染对象叠加
	*/
	class Layer : public IRenderable {
	public:
		std::string name;
		char layer[SIZE][SIZE]{ ' ' };

		Layer(std::string name = "Unnamed") {
			this->name = name;
		}

		~Layer() { // 回收图层数组
			for (uint i = 0; i < SIZE; i++)
			{
				delete[] layer[i];
			}
			delete[] layer;
		}

		Layer* join(Layer* layer) { // 合并两个图层
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
	* 渲染系统，用于渲染图层
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

		void render(Layer* layer) { // 渲染图层，同一时间只能渲染一个
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
			if (debug) std::cout << layer->name << "图层渲染完毕，耗时" << double(end - begin) / CLOCKS_PER_SEC * 1000 << "毫秒。";
		}

		void flush() {
			if (current == nullptr) return;
			render(current);
		}

		void filter(const char* color) { // 滤镜
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
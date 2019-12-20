// lr_1_swqat.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
#include "string.h"

using namespace std;

void _tmain(int argc, _TCHAR* argv[]){

	int choice, *Array = new int[10];
	for (int i = 0; i < 10; i++) {
		Array[i] = rand() % 10;
	}

	cout << "Insert 1 or 2: ";
	cin >> choice;
	cin.clear();

	if (choice == 1) {
		//сортировка методом выбора
		int temp = 0, i = 0, j = 0;
		for (j = 0; j < 9; j++) {
			//цыкл для сдвига указателя
			for (i = j + 1; i < 10; i++) {
				//цыкл для перебора элементов
				if (Array[j] > Array[i]) {
					temp = Array[j];
					Array[j] = Array[i];
					Array[i] = temp;
				}
			}
		}
	} 
	else if (choice == 2) {
		//сортировка пузырьком
		int temp = 0, i =0 , j = 0;
		for (j = 0; j < 6; j++) {
			for (i = 0; i < 10 - j; i++) {
				if (Array[i] < Array[i+1]) {
					temp = Array[i];
					Array[i] = Array[i+1];
					Array[i+1] = temp;
				}
			}
		}
	}
	else {
		cout << "Inserted value is not correct!\n";
		system("pause");
		return;
	}
	for (int i= 0; i < 10; i++) {
		cout<<Array[i];
	}
	cout<<endl;

	system("pause");
}
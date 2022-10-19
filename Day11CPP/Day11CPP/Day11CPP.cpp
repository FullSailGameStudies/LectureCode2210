// Day11CPP.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>

using namespace std;//generally considered to be bad.

typedef long long Batman;

enum Superpower
{
    Speed, Invisibility, Money, Swimming
};

//forward declaration
void printPower(Superpower power);

int main()
{
    //std -- standard namespace
    //:: -- scope resolution operator
    //cout -- console output stream
    //<< -- insertion operator
    int number = 5;
    bool isGood = true;
    double grade = 59.5;
    char b = 'B';
    Batman bMan = 5;
    std::cout << "Hello Gotham!\n" << number << "\nBatman rules!\n";
    cout << "Size of char: " << sizeof(b) << "byte(s)\n";

    char best[] = "Batman";//adds a \0 (null terminator) to the end
    char meh[] = { 'A','q','u','a','m','a','n', '\0'};//does NOT add \0
    cout << best << "\n" << meh << "\n";

    for (int i = 0; i < sizeof(best)/sizeof(char); i++)
    {
        cout << best[i] << ' ';
    }

    
    srand(time(NULL));
    int rNum = rand();//0-RAND_MAX (32767)
    int rGrade = rand()%101;//0-100 modulus operator. remainder of a division

    for (size_t i = 0; i < 100; i++)
    {
        cout << rand() << "\n";
    }

    Superpower powers = Superpower::Swimming;
    cout << powers << "\n";

    printPower(powers);

    vector<int> highScores;//stack instance
    highScores.push_back(rand());//like the List's Add method
    highScores.push_back(rand());
    highScores.push_back(rand());
    highScores.push_back(rand());
    highScores.push_back(rand());
    cout << "HIGH SCORES\n";
    for (size_t i = 0; i < highScores.size(); i++)
    {
        cout << highScores[i] << "\n";
    }
}

void printPower(Superpower power)
{
    switch (power)
    {
    case Speed:
        break;
    case Invisibility:
        break;
    case Money:
        break;
    case Swimming:
        break;
    default:
        break;
    }
}
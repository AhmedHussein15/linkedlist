#include <iostream>
using namespace std;

class Node
{
    public:
    int data;
    Node* next;
    Node(int data)
    {
        this->data = data;
        this->next = NULL;
    }
};

class LinkedList
{
    public:
    Node* head;

    LinkedList()
    {
        head = NULL;
    }


    void insert(int data)
    {
        Node* newNode = new Node(data);
        if (head == NULL)
        {
            head = newNode;
        }
        else
        {
            Node* temp = head;
            while (temp->next != NULL)
            {
                temp = temp->next;
            }
            temp->next = newNode;
        }
    }


    void deleteNode(int data)
    {
        Node* temp = head;
        Node* prev = NULL;

        if (temp != NULL && temp->data == data)
        {
            head = temp->next;
            delete temp;
            return;
        }

        while (temp != NULL && temp->data != data)
        {
            prev = temp;
            temp = temp->next;
        }

        if (temp == NULL)
        {
            return;
        }

        prev->next = temp->next;
        delete temp;
    }


    void printList()
    {
        Node* temp = head;
        while (temp != NULL)
        {
            cout << temp->data << " ";
            temp = temp->next;
        }
        cout << endl;
    }


    bool search(int data)
    {
        Node* temp = head;
        int counter = 1;
        while (temp != NULL)
        {
            if (temp->data == data)
            {
                cout << "found : " << counter << endl;
                deleteNode(data);
                return true;
            }
            counter++;
            temp = temp->next;
        }
        return false;
    }
};

int main()
{
    LinkedList list;
    list.insert(1);
    list.insert(2);
    list.insert(3);
    list.insert(4);
    list.printList();
    list.deleteNode(3);
    list.printList();
    list.search(2);
    list.printList();
    return 0;
}

using System;


namespace Assignment3
{
    class Linkedlist<T>
    {
        public class Node{
            private T data;
            private Node next;

            public Node(T t)
            {
                next = null;
                data = t;
            }

            public T Data {
                get{return this.data; }
                set{this.data = value; }
            }
             public Node Next {
                get{return this.next; }
                set{this.next = value; }
            }

        }
        
        
        
        private int size;
        public Node head;
        public Linkedlist(){
            this.head = null;
            this.size = 0;
        }
        public bool Empty {
            get {return this.size == 0; }
        }
        public int Size {
            get {return this.size;}
        }

        public T Add(int index, T data){
            
            if( index > size){
                index = size;
            }
            Node current =  this.head;

            if(this.Empty ){
                this.size++;
                this.head =  new Node(data);
                
                return this.head.Data;
            } else if(index == 0){
                this.head =  new Node(data);
                this.head.Next = current;
            }else {
                for(int i = 0; i < index-1; i++){
                    current = current.Next;
                }
                Node temp = current.Next;
                current.Next = new Node(data);
                current.Next.Next = temp;
            }
            this.size++;
            return data;
        }
        public T Add(T data){
            return this.Add(size,data);
        }

        public T Remove(int index){
            if( index < 0){
                Console.WriteLine("Can't be negative");
                return default(T);
            }
            if(this.Empty) {
                return default(T);
            }
            if(index > this.size){
                index = size;
                Console.WriteLine("Removing from end");
            }
            Node current = this.head;
            T result = default(T);

            if(index == 0) {
                result = current.Data;
                this.head = current.Next;
            } else {
                Node prev = head;
                for(int i = 0; i < index; i++) {
                    prev = current;
                    current = current.Next;
                }
                result = current.Data;
                prev.Next = current.Next;
            }
            size--;


            return result;
        }

        public int IndexOf(T obj){
            Node current = this.head;
        
            for(int i = 0; i < this.size; i++){
                if(current.Data.Equals(obj)){
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }
        public Node Get(int index){
            if(this.Empty){
                return null;
            }
            if(index >= this.size) {
                index = this.size -1;
            }

            Node current = this.head;

            for(int i = 0; i <index; i++){
                current =  current.Next;
            }
            return current;
        }
        
    }
}

using System;
using System.Collections.Generic;


namespace Assignment3
{
    class Program
    {
        static Linkedlist<int> list;
        static void Main(string[] args)
        {
           
           start();
           
        }

        public static void start(){
            string answer = "-1";
            do{
                Console.WriteLine("Welcome to my linked list implementation \n" + 
                "Select any of the options below (A-K) or type Z to exit");

                Console.WriteLine("A. Creating a new Single Linked List \n" + 
                    "B. Displaying the list \n" +
                    "C. Adding an element at the beginning of the list. \n" +
                    "D. Removing an element at the beginning of the list. \n" +
                    "E. Adding an element at the end of the list.  \n" +
                    "F. Removing an element at the end of the list.  \n" +
                    "G. Adding an element at the nth position.  \n" +
                    "H. Removing an element at the nth position.  \n" +
                    "I. Reverse the List \n" +
                    "J. Bubble Sort by exchanging data \n" +
                    "K. Bubble Sort by exchanging links \n" +
                    "L. Insert Cycle \n" +
                    "M. Detect Cycle \n" +
                    "N. Remove Cycle \n" 
                
                );
                answer = Console.ReadLine();
                
                if(list != null || answer.Equals("A")){
                    
                    switch(answer) {
                        case "A":
                            create();
                            break;
                        case "B":
                            displayList();
                            break;
                        case "C":
                            addToStart();
                            break;
                        case "D":
                            removeFromStart();
                            break;
                        case "E":
                            addToEnd();
                            break;
                        case "F":
                            removeFromEnd();
                            break;
                        case "G":
                            addToPosition();
                            break;
                        case "H":
                            removeFromPosition();
                            break;
                        case "I":
                            reverseList();
                            break;
                        case "J":
                            bubbleSort();
                            break;
                        case "K":
                            bubbleSortLinks();
                            break;
                        case "L":
                            insertCycle();
                            break;
                        case "M":
                            detectCycle();
                            break;
                        case "N":
                            removeCycle();
                            break;
                        default:
                            
                            break;
                        }
                } 
                if(list == null) {
                    Console.WriteLine("Please create a linkedlist! \n");
                }
            }while(answer!= "Z");
        }

        
        public static void create(){
            list = new Linkedlist<int>();
            Console.WriteLine("Created List \n");
        }
        public static void displayList(){
            var curr = list.head;
            
            while(curr != null){
                Console.WriteLine(curr.Data);
                curr = curr.Next;
            }
                
                
            
            
        }
        public static void addToStart(){
            Console.WriteLine("What data would you like to enter");
            int answer;
            bool success = int.TryParse(Console.ReadLine(),out answer);
            if(success){
                Console.WriteLine("entered number");
                list.Add(0,answer);
            }
            
            
        }
        public static void removeFromStart(){
            list.Remove(0);
        }
        public static void addToEnd(){
            Console.WriteLine("What data would you like to enter");
            int answer;
            bool success = int.TryParse(Console.ReadLine(),out answer);
            if(success){
                list.Add(answer);
            }
        }
        public static void removeFromEnd(){
            list.Remove(list.Size);
        }

        public static void addToPosition(){
            Console.WriteLine("What data would you like to enter");
            int data;
            bool success = int.TryParse(Console.ReadLine(),out data);

            Console.WriteLine("What index would you like to insert at?");
            int index;
            bool isParsable = int.TryParse(Console.ReadLine(), out index);

            if(isParsable && success) {
                list.Add(index,data);
            } else {
                Console.WriteLine("Not a number");
            }
            
        }
        public static void removeFromPosition(){
            Console.WriteLine("What index would you like removed?");
            string answer = Console.ReadLine();
            int index;
            bool isParsable = Int32.TryParse(answer, out index);
            if(isParsable) {
                list.Remove(index);
            } else {
                Console.WriteLine("Not a number");
            }
            
        }
        public static void reverseList(){
           


            if(list.Size > 0){
                                
                
                var prev = list.head;
                var curr = list.head.Next; 
                var next = curr.Next;
                
                prev.Next = null;

                while(curr != null) {
                    
                    curr.Next = prev;

                    prev = curr;

                    curr= next;

                    if(next != null){
                        next = curr.Next;
                    }
                    
                }
                list.head = prev;

            }
        }

        public static void bubbleSort(){
            // put all data into an array
            
            
            
            for(int i = 0; i < list.Size - 1; i++){
                
                for(int j = 0; j < list.Size - 1 - i; j++){
                    if(list.Get(j).Data > list.Get(j + 1).Data){
                        var data = list.Get(j).Data; // 5
                        list.Get(j).Data = list.Get(j + 1).Data; // 3
                        list.Get(j + 1).Data = data;
                    }
                }
            }
            
        }

        public static void bubbleSortLinks(){
            // put all data into an array
            
            
            
            for(int i = 0; i < list.Size - 1; i++){
                
                for(int j = 0; j < list.Size - 1 - i; j++){
                    if(list.Get(j).Data > list.Get(j + 1).Data){
                        
                        var bigNode = list.Get(j); 
                        var smallNode = list.Get(j+1);
                        if( list.Size == 2){
                            reverseList();
                        }else if(j == 0){
                            
                            bigNode.Next = smallNode.Next;
                            smallNode.Next = bigNode;
                            list.head = smallNode;
                        }else if(smallNode.Next == null){ 
                            
                            list.Get(j-1).Next = smallNode;
                            smallNode.Next = bigNode;
                            bigNode.Next = null;
                        }else {
                            
                            list.Get(j-1).Next = smallNode; 
                            bigNode.Next = smallNode.Next;
                            smallNode.Next = bigNode;
                        }

                        
                    }
                }
            }
            
        }

        public static void insertCycle(){
            int size = list.Size;

            if(size <= 2){
                list.Get(1).Next = list.head;
            } else{
                list.Get(size-1).Next = list.Get(size/2);
            }
        }

        public static void detectCycle(){
            if(list.head != null){
                var turtle = list.head;
                var hare = turtle;
                bool cycleDetected = false;

                while(!cycleDetected && hare.Next != null){
                    turtle = turtle.Next;
                    
                    hare = hare.Next;
                    if(hare.Next != null){
                        hare = hare.Next;
                    }

                    if(turtle == hare){
                        cycleDetected = true;
                    }
                }

                if(cycleDetected){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A cycle was detected!");
                    Console.ForegroundColor = ConsoleColor.White;
                } else{
                    Console.WriteLine("No cycle was detected!");
                }
            }else {
                Console.WriteLine("List is Empty");
            }
            
            
        }

        public static void removeCycle(){
            var turtle = list.head;
            var hare = turtle;
            
            bool cycleDetected = false;

            while(!cycleDetected && hare != null){
                turtle = turtle.Next;
                
                hare = hare.Next.Next;

                if(turtle == hare){
                    cycleDetected = true;
                }
            }
            Console.WriteLine("Cycle not Removed");
            if(cycleDetected){
                Console.WriteLine("Cycle Removed");
                bool startLap = false;
                turtle = list.head;
                
                while(!startLap){
                    hare = hare.Next;
                    turtle = turtle.Next;
                    if(hare == turtle){
                        startLap = true;
                    } 
                }
                hare = hare.Next;
                while(hare.Next != turtle) {
                    hare = hare.Next;
                }
                hare.Next = null;
                Console.WriteLine("Cycle Removed");
            }



        }
    }
}

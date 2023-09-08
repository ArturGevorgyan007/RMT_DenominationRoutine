using System.Collections.Generic;

//You can modify here to your desired combination of input
int[] cartridge = new int[] {50,100,10};
int money = 980;

//Index for counting denominations
int index=1;

//Initialization of Dictionary of Key: Banknote, Value: Count and using Recursive function
for (int j = 0; j < cartridge.Length; j++){
    List<int> listOfNotes = new List<int>();
    Dictionary<int,int> denomination = new Dictionary<int,int>();
    for (int k = 0; k < cartridge.Length; k++)
        denomination[cartridge[k]] = 0;

    recur(cartridge,cartridge[j],money,listOfNotes,denomination);
}


void recur(int[] X, int current, int Y, List<int> listOfNotes,Dictionary<int,int> denomination) {
    Y=Y-current;
    if(listOfNotes.Count==0){
        listOfNotes.Add(current);
        denomination[current]++;
    }
    else if (current>listOfNotes.Last())
        return;
    else {
        listOfNotes.Add(current);
        denomination[current]++;
    }
    
    if(Y==0){
        Console.WriteLine("Denomination {0}", index);
        foreach(var el in denomination)
            Console.WriteLine("({0} EUR, Count: {1})",el.Key,el.Value);
        index++;
        return;
    }

    for(int i=0;i<X.Length;i++)
    {
        if(Y>=X[i]){
            recur(X,X[i],Y,new List<int>(listOfNotes), new Dictionary<int, int>(denomination));
        }
    }
}

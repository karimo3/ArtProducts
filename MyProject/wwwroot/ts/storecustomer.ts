 export class StoreCustomer {

    //not supported in C# --> 
    constructor(private firstName: string, private lastName: string) {
      
    }

    public visits: number = 0;  //use the colon to declare the type of the variable...type safety is only validated at runtime, not at compile time
    public ourName: string;

    public showName() {
        alert(this.firstName + " " + this.lastName);

    }

    //accessors (form of a function)
    set name(val) {
        this.ourName = val;
    }

    get name() {
        return this.ourName;
    }



}
// See https://aka.ms/new-console-template for more information
using ErpExercise;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to my Inventory Console App");
        Console.WriteLine("");
        Console.WriteLine("Choose de desired option");
        Console.WriteLine("");

        bool keepRunning = true;

        List<InventoryItem> items = new List<InventoryItem>();

        int itemId = 1;

        do
        {
            Console.WriteLine("\n###################################################################\n");
            Console.WriteLine("\n1-Add a new Item\n");
            Console.WriteLine("2-Remove one product of the inventory\n");
            Console.WriteLine("3-Update quantity\n");
            Console.WriteLine("4-Show all items\n");
            Console.WriteLine("5-Search Product\n");
            Console.WriteLine("6-See which are below a certain quantity\n");
            Console.WriteLine("7-Order by stock\n");
            Console.WriteLine("9-End Program\n");
            Console.WriteLine("\n###################################################################\n");

            var optionChosen = Console.ReadLine();

            if (optionChosen == "1")
            {
                var newItem = new InventoryItem()
                {
                    Id = itemId,
                };

                Console.WriteLine("\nType the name of the item\n");

                var itemName = Console.ReadLine();

                if (!string.IsNullOrEmpty(itemName))
                {
                    newItem.Name = itemName;
                }

                Console.WriteLine("\nType the price of the item\n");

                var tryParsePrice = false;

                do
                {

                    var itemPrice = Console.ReadLine();

                    if (itemPrice == "Exit")
                    {
                        tryParsePrice = false;
                        break;
                    }

                    tryParsePrice = decimal.TryParse(itemPrice, out decimal itemPriceDecimal);
                    if (tryParsePrice)
                    {
                        newItem.Price = itemPriceDecimal;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease write a real number for the Price!Type 'Exit' to quit the menu.\n");
                        continue;
                    }

                } while (tryParsePrice == false);

                Console.WriteLine("\nType the quantity of the item\n");

                var tryParseQuantity = false;

                do
                {
                    var itemQuantity = Console.ReadLine();
                    if (!string.IsNullOrEmpty(itemQuantity))
                    {
                        if (itemQuantity == "Exit")
                        {
                            tryParseQuantity = false;
                            break;
                        }
                        tryParseQuantity = int.TryParse(itemQuantity, out int itemQuantityInt);
                        if (tryParseQuantity)
                        {
                            newItem.Quantity = itemQuantityInt;
                        }
                        else
                        {
                            Console.WriteLine("\nPlease write a real number for the Quantity! Type 'Exit' to quit this menu.\n");
                            continue;
                        }

                    }
                } while (tryParseQuantity == false);

                if( tryParsePrice && tryParseQuantity) 
                {
                    items.Add(newItem);

                    itemId++;

                    Console.WriteLine($"\nItem added! Now the list has {items.Count} items\n");
                }
                
            }
            else if (optionChosen == "2")
            {

                if (items.Count == 0)
                {
                    Console.WriteLine("\nThe list is empty\n");
                    continue;
                }
                else
                {
                    Console.WriteLine("\n\nThis is the list of existing items\n");

                    foreach (var item in items)
                    {

                        Console.WriteLine($"\nId: {item.Id} - Name: {item.Name} - Price: {item.Price} - Quantity: {item.Quantity}");
                    }
                }

                InventoryItem itemInList = null;

                do
                {
                    Console.WriteLine("\nType the Id of the item that you want to delete\n");
                    var idToRemove = Console.ReadLine();
                    if (idToRemove == "Exit")
                    {
                        break;
                    }
                    itemInList = items.Where(x => x.Id == Convert.ToInt32(idToRemove)).FirstOrDefault();

                    if (itemInList == null)
                    {
                        Console.WriteLine("\nThere is no item with that Id. Type 'Exit to quit the menu.'\n");
                        continue;
                    }
                    else
                    {
                        items.Remove(itemInList);
                        Console.WriteLine("\nItem Removed!\n");
                        continue;
                    }
                } while (itemInList == null);

                


            }
            else if (optionChosen == "3")
            {

                if (items.Count == 0)
                {
                    Console.WriteLine("\nThe list is empty\n");
                    continue;
                }
                else
                {
                    Console.WriteLine("\n\nThis is the list of existing items\n");
                    foreach (var item in items)
                    {

                        Console.WriteLine($"\nId: {item.Id} - Name: {item.Name} - Price: {item.Price} - Quantity: {item.Quantity}");
                    }
                }
                InventoryItem itemInList = null;
                do
                {
                    Console.WriteLine("\nType the Id of the item that you want to update the quantity\n");

                    var idToRemove = Console.ReadLine();
                    if(idToRemove == "Exit")
                    {
                        break;
                    }

                    itemInList = items.Where(x => x.Id == Convert.ToInt32(idToRemove)).FirstOrDefault();

                    if (itemInList == null)
                    {
                        Console.WriteLine("\nThere is no item with that Id. Type 'Exit' to quit the menu.\n\n");
                        continue;
                    }
                    else
                    {
                        bool tryParse = false;
                        do
                        {
                            Console.WriteLine("\nWhat is the new quantity?\n\n");
                            var newQuantiy = Console.ReadLine();
                            if (newQuantiy == "Exit")
                                break;

                            tryParse = int.TryParse(newQuantiy, out int newQuantityInt);

                            if (tryParse)
                            {

                                itemInList.Quantity = newQuantityInt;
                            }
                            else
                            {
                                Console.WriteLine("\nPlease write a real number for the Quantity! Type 'Exit' to quit\n\n");
                                break;
                            }
                        } while (tryParse == false);


                        Console.WriteLine("\nQuantity Updated!\n");
                        continue;
                    }
                } while (itemInList == null);

               


            }
            else if (optionChosen == "4")
            {
                if (items.Count == 0)
                {
                    Console.WriteLine("\nThe list is empty\n");
                    continue;
                }
                else
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine($"\nId: {item.Id} - Name: {item.Name} - Price: {item.Price} - Quantity: {item.Quantity}");
                    }
                }

            }

            else if (optionChosen == "5")
            {

                if (items.Count == 0)
                {
                    Console.WriteLine("\nThe list is empty\n");
                    continue;
                }
                else
                {
                    List<InventoryItem> itemListFiltered = new List<InventoryItem>();

                    do
                    {
                        Console.WriteLine("\n\nType the name of the item to search (it is case sensitive)\n");

                        var filterWord = Console.ReadLine();
                        if (filterWord == "Exit")
                            break;

                        itemListFiltered = items.Where(x => x.Name.Contains(filterWord)).ToList();
                        if (itemListFiltered.Count > 0)
                        {
                            Console.WriteLine("\n\nThese are the items that contain your search word:\n");
                            foreach (var item in itemListFiltered)
                            {
                                Console.WriteLine($"\nId: {item.Id} - Name: {item.Name} - Price: {item.Price} - Quantity: {item.Quantity}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nNo items where found with that name. Please try another name or type 'Exit' to quit this menu.\n");
                        }
                        
                    } while (itemListFiltered.Count == 0);
                    
                }
            }
            else if (optionChosen == "6")
            {

                if (items.Count == 0)
                {
                    Console.WriteLine("\nThe list is empty\n");
                    continue;
                }
                else
                {
                    var tryParse = false;

                    do
                    {

                        Console.WriteLine("\n\nType the limit of the quantity:\n");
                        var maxQuantity = Console.ReadLine();
                        tryParse = int.TryParse(maxQuantity, out int itemQuantity);
                        if (tryParse==false)
                        {
                            Console.WriteLine("\n\nPlease type a real number\n");
                            continue;
                        }

                        var itemListFiltered = items.Where(x => x.Quantity < itemQuantity).ToList();
                        if (itemListFiltered.Count > 0)
                        {
                            Console.WriteLine("\n\nThese are the items that are below that quantity:\n");
                            foreach (var item in itemListFiltered)
                            {
                                Console.WriteLine($"\nId: {item.Id} - Name: {item.Name} - Price: {item.Price} - Quantity: {item.Quantity}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\nThere are no items below this quantity.");
                        }
                    } while (tryParse == false);


                }
            }
            else if (optionChosen == "7")
            {

                if (items.Count == 0)
                {
                    Console.WriteLine("\nThe list is empty\n");
                    continue;
                }
                else
                {
                    var itemByStock = items.OrderBy(x => x.Quantity);
                    Console.WriteLine("\n\nThese are the items order by stock quantity:\n");
                    foreach (var item in itemByStock)
                    {
                        Console.WriteLine($"\nId: {item.Id} - Name: {item.Name} - Price: {item.Price} - Quantity: {item.Quantity}");
                    }
                }
            }
            else if (optionChosen == "9")
            {
                keepRunning = false;

            }
            else
            {
                Console.WriteLine("\n\n\nPlease choose an item from the list.\n");
            }

        } while (keepRunning);


        Console.WriteLine("\n\nThanks for using my console inventory app!\n\n");
    }
}
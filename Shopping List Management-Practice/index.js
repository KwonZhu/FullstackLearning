const readline = require('readline');
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

let grocery = [
  { name: 'milk', price: 7, quantity: 100 },
  { name: 'egg', price: 8, quantity: 100 },
  { name: 'bread', price: 5, quantity: 100 },
  { name: 'lettuce', price: 4, quantity: 100 },
  { name: 'carrot', price: 2, quantity: 100 },
  { name: 'chicken', price: 10, quantity: 100 },
  { name: 'tissue', price: 4, quantity: 100 },
  { name: 'beef', price: 20, quantity: 100 },
];

let shoppingList = [
  { name: 'onion', price: 2, quantity: 2 },
  { name: 'biscuit', price: 3, quantity: 3 },
];

function showOriginalShoppingList() {
  console.log('Your current cart:');
  shoppingList.forEach((item, index) => {
    console.log(`${index + 1}. ${item.name}: ${item.quantity} item(s)`);
  });
}

function showGroceryList() {
  console.log('\nGrocery List:');
  grocery.forEach((item, index) => {
    console.log(`${index + 1}. ${item.name}  Price: $${item.price}  Available: ${item.quantity}`);
  });
}

function askForInput() {
  rl.question('\nEnter the name of the item would you like to buy: ', (name) => {
    // Based on name, return the first matched item or undefined;
    const item = grocery.find((i) => i.name.toLowerCase() === name.toLowerCase());
    // when the name is available in grocery
    if (item) {
      rl.question(`How many ${item.name} would you like to buy? Available: ${item.quantity}: `, (quantity) => {
        quantity = parseInt(quantity);
        // legal && buyable quantity
        if (!isNaN(quantity) && quantity > 0 && quantity <= item.quantity) {
          shoppingList.push({ name: item.name, price: item.price, quantity: quantity });
          console.log(`Added ${quantity} ${item.name}(s) to your cart.`);
          // update availability
          item.quantity = item.quantity - quantity;
        } else {
          console.log('Invalid quantity.');
        }
        askToContinue();
      });
    } else {
      console.log('Item not found.');
      askToContinue();
    }
  });
}

// add more items or retry when input is illegal
function askToContinue() {
  rl.question('\nWould you like to add another item? (yes/no): ', (answer) => {
    // continue/finish input, show shoppingList at the end
    if (answer.toLowerCase() === 'yes') {
      askForInput();
    } else {
      showShoppingList();
      askToDelete();
    }
  });
}

function showShoppingList() {
  console.log('\nYour cart:');
  let total = 0;
  shoppingList.forEach((item, index) => {
    total += item.price * item.quantity;
    console.log(`${index + 1}. ${item.name}: ${item.quantity} item(s)`);
  });
  console.log(`total:  $${total}`);
}

function askToDelete() {
  rl.question('\nWould you like to modify your cart? (yes/no): ', (answer) => {
    if (answer.toLowerCase() === 'yes') {
      rl.question('\nWhich item would you like to delete? (Enter the number)', (cartNumber) => {
        cartNumber = parseInt(cartNumber);
        // legal && within bounds of shoppingList
        if (!isNaN(cartNumber) && cartNumber > 0 && cartNumber <= shoppingList.length) {
          deleteShoppingListItem(cartNumber);
        } else {
          console.log('Invalid number.');
          askToDelete();
          // multiple times incorrect number
          // return to avoid closing rl prematurely
          return;
        }
        rl.close();
        showShoppingList();
      });
    } else {
      rl.close();
      showShoppingList();
    }
  });
}

function deleteShoppingListItem(cartNumber) {
  shoppingList.splice(cartNumber - 1, 1);
}

// Start the process
showGroceryList();
showOriginalShoppingList();
askForInput();

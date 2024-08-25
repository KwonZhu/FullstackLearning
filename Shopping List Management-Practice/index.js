const readline = require('readline');

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

let shoppingList = [];

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

function showGroceryList() {
  console.log('Grocery List:');
  grocery.forEach((item, index) => {
    console.log(`${index + 1}. ${item.name} | Price: $${item.price}, Available: ${item.quantity}`);
  });
}

function askForInput() {
  rl.question('Enter the name of the item you want to buy: ', (name) => {
    // return the first matched item or undefined;
    const item = grocery.find((g) => g.name.toLowerCase() === name.toLowerCase());
    if (item) {
      rl.question(`How many ${item.name} do you want to buy? Available: ${item.quantity}: `, (quantity) => {
        quantity = parseInt(quantity);
        // legal input && buyable
        if (!isNaN(quantity) && quantity > 0 && quantity <= item.quantity) {
          shoppingList.push({ name: item.name, quantity: quantity });
          console.log(`Added ${quantity} ${item.name}(s) to your selection.`);
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
  rl.question('Would you like to add another item? (yes/no): ', (answer) => {
    if (answer.toLowerCase() === 'yes') {
      askForInput();
    } else {
      showUserSelections();
      rl.close();
    }
  });
}

function showUserSelections() {
  console.log('\nYour selections:');
  shoppingList.forEach((selection, index) => {
    console.log(`${index + 1}. ${selection.name}: ${selection.quantity} item(s)`);
  });
}

// Start the process
showGroceryList();
askForInput();

/*
function showGrocery() {
  for (let index = 0; index < grocery.length; index++) {
    console.log(index + '. ' + grocery[index].name + ' | price ' + grocery[index].price);
  }
}

showGrocery();

function addToList(goods) {
  if (goods) {
    // when goods goods is valid & in not in shoppingList
    if (shoppingList.findIndex((i) => i === goods) == -1) {
      shoppingList.push(goods);
      return true;
    }
    return console.log(`Sorry, ${goods} is already in shopping cart`);
  }
  return false;
}
addToList('');
addToList('carrot');
addToList('chicken');
addToList('chicken');
console.log(shoppingList);

function deleteGoods() {
  if (shoppingList.length > 0) {
    shoppingList.pop();
  }
}
deleteGoods();
console.log(shoppingList);

function checkShoppingList() {
  if (shoppingList.length > 5) {
    console.log('Sorry, your shopping cart is full');
  }
  for (let index = 0; index < shoppingList.length; index++) {
    console.log(index + 1 + '. ' + shoppingList[index]);
  }
}
checkShoppingList();
*/

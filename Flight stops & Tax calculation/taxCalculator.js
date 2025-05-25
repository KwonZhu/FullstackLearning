/*
Income thresholds Rate Tax payable on this income
0 – $18,200                           Nil
$18,201 – $45,000                     16c for each $1 over $18,200
$45,001 – $135,000                    $4,288 plus 30c for each $1 over $45,000
$135,001 – $190,000                   $31,288 plus 37c for each $1 over $135,000
$190,001 and over                     $51,638 plus 45c for each $1 over $190,000
*/

// version 1
const table = [
  {
    min: 0,
    max: 18200,
    floor: 0,
    base: 0,
    rate: 0,
  },
  { min: 18201, max: 45000, floor: 18200, base: 0, rate: 0.16 },
  { min: 45001, max: 135000, floor: 45000, base: 4288, rate: 0.3 },
  { min: 135001, max: 190000, floor: 135000, base: 31288, rate: 0.37 },
  {
    min: 190001,
    max: Number.POSITIVE_INFINITY,
    floor: 190000,
    base: 51638,
    rate: 0.45,
  },
];

function taxCalculator(income) {
  let index = 0;
  for (index; index < table.length; index++) {
    if (income >= table[index].min && income <= table[index].max) {
      break;
    }
  }
  // destructuring
  const { floor, base, rate } = table[index];
  tax = (income - floor) * rate + base;
  console.log("Payable tax: $" + tax);
}

taxCalculator(0);

// version 2
const table_2 = [
  {
    min: 0,
    max: 18200,
    base: 0,
    rate: 0,
  },
  { min: 18201, max: 45000, base: 0, rate: 0.16 },
  { min: 45001, max: 135000, base: 4288, rate: 0.3 },
  { min: 135001, max: 190000, base: 31288, rate: 0.37 },
  { min: 190001, max: Infinity, base: 51638, rate: 0.45 },
];

function calculateTax(income, table_2) {
  const range = table_2.find((item) => item.min < income && item.max > income);

  const [min, base, rate] = range;
  return base + (income - min) * rate;
}
calculateTax(100000);

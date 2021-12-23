class Transfer {
  final int accountNumber;
  final double value;

  Transfer(this.value, this.accountNumber);

  @override
  String toString() {
    return 'Transfer{accountNumber: $accountNumber, value: $value}';
  }
}
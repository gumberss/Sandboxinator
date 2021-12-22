import 'package:flutter/material.dart';

void main() => runApp(App());

class TransferForm extends StatelessWidget {
  final TextEditingController _accountNumberFieldController =
      TextEditingController();
  final TextEditingController _valueFieldController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Transfer form"),
      ),
      body: Column(
        children: [
          Editor(
            label: "Account Number",
            hint: "000000",
            controller: _accountNumberFieldController,
          ),
          Editor(
              label: "Value",
              hint: "00.00",
              controller: _valueFieldController,
              icon: Icons.monetization_on),
          ElevatedButton(onPressed: createTransfer, child: Text("Confirm"))
        ],
      ),
    );
  }

  void createTransfer() {
    final double? value = double.tryParse(_valueFieldController.text);
    final int? accountNumber = int.tryParse(_accountNumberFieldController.text);
    if (value != null && accountNumber != null) {
      final createdTransfer = Transfer(value, accountNumber);

      debugPrint('$createdTransfer');
    }
  }
}

class Editor extends StatelessWidget {
  final String? label;
  final String? hint;
  final TextEditingController? controller;
  final IconData? icon;

  Editor(
      {required this.label,
      required this.hint,
      required this.controller,
      this.icon});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(16.0),
      child: TextField(
        controller: controller,
        style: TextStyle(
          fontSize: 24,
        ),
        decoration: InputDecoration(
            labelText: label,
            hintText: hint,
            icon: icon != null ? Icon(icon) : null),
        keyboardType: TextInputType.number,
      ),
    );
  }
}

class App extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(body: TransferForm()),
    );
  }
}

class TransferList extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          TransferItem(Transfer(100.21, 123421)),
          TransferItem(Transfer(1000, 123421)),
          TransferItem(Transfer(10000.23, 123421))
        ],
      ),
      appBar: AppBar(
        title: Text("Transfer"),
      ),
      floatingActionButton: FloatingActionButton(
        child: Icon(Icons.add),
        onPressed: () => {},
      ),
    );
  }
}

class TransferItem extends StatelessWidget {
  final Transfer _transfer;

  TransferItem(this._transfer);

  @override
  Widget build(BuildContext context) {
    return Card(
        child: ListTile(
      leading: Icon(Icons.monetization_on),
      title: Text(_transfer.value.toString()),
      subtitle: Text(_transfer.accountNumber.toString()),
    ));
  }
}

class Transfer {
  final int accountNumber;
  final double value;

  Transfer(this.value, this.accountNumber);

  @override
  String toString() {
    return 'Transfer{accountNumber: $accountNumber, value: $value}';
  }
}

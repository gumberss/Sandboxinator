import 'package:firstapi/models/transfer.dart';
import 'package:firstapi/screens/transfer_form.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class TransferList extends StatefulWidget {
  final List<Transfer> _transfers = List.empty(growable: true);

  @override
  State<StatefulWidget> createState() {
    return TransferListState();
  }
}

class TransferListState extends State<TransferList> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Transfer"),
      ),
      body: ListView.builder(
        itemCount: widget._transfers.length,
        itemBuilder: (ctx, index) {
          final transfer = widget._transfers[index];
          return TransferItem(transfer);
        },
      ),
      floatingActionButton: FloatingActionButton(
        child: Icon(Icons.add),
        onPressed: () {
          final Future<Transfer?> future = Navigator.push(
              context, MaterialPageRoute(builder: (context) => TransferForm()));
          future.then((receivedTransfer) {
            if (receivedTransfer != null) {
              setState(() => widget._transfers.add(receivedTransfer));
            }
          });
        },
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
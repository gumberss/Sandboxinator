import 'contact.dart';

class Transaction {
  final String id;
  final double value;
  final Contact contact;

  Transaction(
      this.id,
      this.value,
      this.contact,
      );

  Transaction.fromJson(Map<String, dynamic> json) :
        id = json['id'],
        value = json['value'],
        contact = Contact.fromJson(json['contact']);

  Map<String, dynamic> toJson() =>
      {
        'value': value,
        'contact': contact.toJson(),
        'id' : id
      };

  @override
  String toString() {
    return 'Transaction{value: $value, contact: $contact}';
  }

}
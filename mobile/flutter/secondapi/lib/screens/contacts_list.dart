import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:secondapi/screens/contact_form.dart';

class ContactsList extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Contacts'),
      ),
      body: ListView(
        children: [
          Card(
            child: ListTile(
              title: Text('Lala', style: TextStyle(fontSize: 24.0),),
              subtitle: Text('1234', style: TextStyle(fontSize: 16.0),),
            ),
          )
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: (){
          Navigator.of(context).push(MaterialPageRoute(builder: (context) => ContactForm()));
        },
        child: Icon(Icons.add),
      ),
    );
  }
}

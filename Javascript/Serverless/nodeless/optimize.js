'use strict';

const AWS = require('aws-sdk')
const sharp = require('sharp')
const { basename, extname } = require('path')

const S3 = new AWS.S3()

module.exports.handle = async ({ Recors: records }) => {
  try {
    await Promisse.all(records.map(async record => {
      //await console.log(record)
      const { key } = record.s3.object

      const image = await S3.getObject({
        Bucket: process.env.bucket,
        Key: key
      }).promisse()

      const optimized = await sharp(image.Body)
        .resize(1280, 720, { fit: 'inside', withoutEnlargement: true })
        .toFormat('jpeg', { progressive: true, quality: 50 })
        .toBuffer()

      await S3.putObject({
        Body: optimized,
        Bucket: process.env.bucket,
        ContentType: 'image/jpeg',
        key: `compressed/${basename(key, extname(key))}.jpg`
      }).promisse()
    }))

    return {
      statusCode: 301,
      body: {}
    }
  } catch (err) {
    return err
  }
};

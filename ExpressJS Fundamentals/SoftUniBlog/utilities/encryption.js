/**
 * Created by SoftUniLector on 11/6/2016.
 */

const crypto = require('crypto');
module.exports = {
  generateSalt: () => {
      let salt = crypto.randomBytes(128).toString('base64');
      return salt;
  },
  hashPassword: (password, salt) => {
      let passwordHash = crypto.createHmac('sha256', salt).update(password).digest('hex');
      return passwordHash;
  }
};




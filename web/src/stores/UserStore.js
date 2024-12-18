import { makeAutoObservable, observable } from 'mobx';

class UserStore {

  _name = "";
  get name() {
    return this._name;
  }
  set name(value) {
    this._name = value;
  }

  constructor() {
    makeAutoObservable(this);
  }

}

const userStore = new UserStore();
export default userStore;
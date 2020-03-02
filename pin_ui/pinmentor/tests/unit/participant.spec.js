import { expect } from 'chai';
import { shallowMount } from '@vue/test-utils';
import Participant from '@/components/Participant.vue';

describe('Participant component', () => {
  it('has a first name', () => {
    const firstName = 'John';

    const wrapper = shallowMount(Participant, {
      propsData: { firstName }
    });

    expect(wrapper.text()).to.include(firstName);
  });

  it('has a last name', () => {
    const lastName = 'Doe';
    const wrapper = shallowMount(Participant, {
      propsData: { lastName }
    });

    expect(wrapper.text()).to.include(lastName);
  });
});

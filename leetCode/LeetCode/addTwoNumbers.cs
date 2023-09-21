/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode result = new ListNode();
        ListNode resultNode = result;
        int carry = 0;
        while(l1 != null || l2 != null){
            int digit1 = 0;
            int digit2 = 0;
            int resultValue = carry;
            if(l1 != null){
                resultValue += l1.val;
                l1 = l1.next;
            }
            if(l2 != null){
                resultValue += l2.val;
                l2 = l2.next;
            }

            if(resultValue >= 10){
                carry = 1;
                resultNode.val = resultValue % 10;
            }else{
                carry = 0;
                resultNode.val = resultValue;
            }
            
            if(l1 != null || l2 != null){
                resultNode.next = new ListNode();
            }else{
                if(carry == 1){
                    resultNode.next = new ListNode(carry, null);
                }else{
                    resultNode.next = null;
                }
            }
            
            resultNode = resultNode.next;
        }


        return result;
    }
}
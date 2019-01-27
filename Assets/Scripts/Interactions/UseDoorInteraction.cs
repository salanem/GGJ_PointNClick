namespace Interactions
{
    public class UseDoorInteraction : Interaction
    {
        public Scene m_NextRoom;

        public override void Interact()
        {
            if (GameManager.Get.m_CurrentInteractionType == m_interactionType)
            {
                GameManager.Get.LoadRoom(m_NextRoom);
                UIManager.Get.DisplayHoverItem(null);
            }
        }
    }
}
